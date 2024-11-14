import os
import shutil

def rename_files_and_folders(directory):
    for root, dirs, files in os.walk(directory):
        for dir in dirs:
            if "ContactMNGR" in dir:
                new_dir = dir.replace("ContactMNGR", "ProductCatalog")
                old_path = os.path.join(root, dir)
                new_path = os.path.join(root, new_dir)
                os.rename(old_path, new_path)
                print(f"Renamed directory: {old_path} -> {new_path}")
        for file in files:
            if "ContactMNGR" in file:
                new_file = file.replace("ContactMNGR", "ProductCatalog")
                old_path = os.path.join(root, file)
                new_path = os.path.join(root, new_file)
                os.rename(old_path, new_path)
                print(f"Renamed file: {old_path} -> {new_path}")

# Example usage
rename_files_and_folders("ContactMNGR")